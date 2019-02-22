using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SubDialogBot
{
    public class ChildDialog : ComponentDialog
    {
        private const string childName = "childName";
        private const string childWaterfallName = "childWaterfallName";
        public ChildDialog() : base(nameof(ChildDialog))
        {
            var waterfallSteps = new WaterfallStep[]
            {
                SayHello
            };
            AddDialog(new WaterfallDialog(childWaterfallName, waterfallSteps));
            AddDialog(new TextPrompt(childName));
        }

        private async Task<DialogTurnResult> SayHello(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync(MessageFactory.Text("Hello from child."));
            return await stepContext.EndDialogAsync();
        }
    }
}
