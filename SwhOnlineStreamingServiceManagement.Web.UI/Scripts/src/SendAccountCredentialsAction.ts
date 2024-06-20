import {
    CluuActionBase, CluuMessageBox, CluuObjectSelectWindow,
    CluuSelectionMode, CluuVoidConstraint, ICluuActionExecutedEventArgs, ICluuActionExecutingEventArgs
} from "cluu";
import { SendAccountCredentialsWindow } from "./SendAccountCredentialsWindow";
import { SwhOnlineStreamingServiceManagement as Entities } from "./entities";

export class SendAccountCredentialsAction extends CluuActionBase {
    public override get name() {
        return "swhOnlineStreamingServiceManagement.web.ui.actions.sendAccountCredentialsAction";
    }

    protected override async executeInternalAsync(args: ICluuActionExecutingEventArgs)
        : Promise<ICluuActionExecutedEventArgs> {
        let accountConstraint = args.applicationContext?.constraint;

        if (accountConstraint == null || accountConstraint instanceof CluuVoidConstraint) {
            const s = Entities.FieldSelection.Account.createFieldSelector();

            const selectAccountWindow = new CluuObjectSelectWindow({
                cluuClassName: s.getCluuClassName(),
                constraint: args.applicationContext?.baseConstraint,
                selectionMode: CluuSelectionMode.Multiple
            });

            if (await selectAccountWindow.showAndWaitForCloseAsync()) {
                accountConstraint = selectAccountWindow.getSelectedConstraint();
            }
            else {
                await CluuMessageBox.showAsync("Account nicht ausgewählt.", "Kein Account");
            }
        }

        const sendWindow = new SendAccountCredentialsWindow({
            accountConstraint: accountConstraint
        });

        await sendWindow.showAndWaitForCloseAsync();

        return { sender: this, result: null };
    }
}
