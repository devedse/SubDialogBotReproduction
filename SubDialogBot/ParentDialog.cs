using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SubDialogBot
{
    public class ParentDialog : ComponentDialog
    {
        private const string waterfallDialogName = "parentName";

        public ParentDialog() : base(nameof(ParentDialog))
        {
            AddDialog(new ChildDialog());

            var waterfallSteps = new WaterfallStep[]
            {
                SayHello,
                SayHello2
            };
            AddDialog(new WaterfallDialog(waterfallDialogName, waterfallSteps));
        }

        private async Task<DialogTurnResult> SayHello(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync(MessageFactory.Text("Hello from parent."));
            return await stepContext.NextAsync();
        }

        private async Task<DialogTurnResult> SayHello2(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync(MessageFactory.Text("Hello from parent2."));
            return await stepContext.NextAsync();
        }
    }
}
