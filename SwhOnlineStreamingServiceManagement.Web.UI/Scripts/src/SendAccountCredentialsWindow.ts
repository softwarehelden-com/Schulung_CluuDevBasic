import {
    CluuConstraint, CluuDialog, CluuLiteralControl, CluuWindowButton,
    DialogSize, DialogStretch, IDefaultCluuWindowOptions
} from "cluu";
import { SwhOnlineStreamingServiceManagement as Entities } from "./entities";

export interface ISendAccountCredentialsWindowOptions extends IDefaultCluuWindowOptions {
    accountConstraint: CluuConstraint;
}

export class SendAccountCredentialsWindow extends CluuDialog {
    private _accountConstraint: CluuConstraint;

    constructor(options: ISendAccountCredentialsWindowOptions) {
        super(options);
    }

    protected override getDefaultOptions(): ISendAccountCredentialsWindowOptions {
        return {
            ...super.getDefaultOptions(),
            title: "Zugangsdaten an Freigegebene senden",
            content: new CluuLiteralControl({ value: "Hier können Sie die Zugangsdaten an die Freigegebenen senden." }),
            accountConstraint: null,
            dialogSize: DialogSize.Medium,
            dialogStretch: DialogStretch.None
        };
    }

    protected override initialize(options: ISendAccountCredentialsWindowOptions): void {
        super.initialize(options);

        this._accountConstraint = options.accountConstraint;

        this.addDefaultAbortWindowButton();

        const buttons = this.getWindowButtons()

        buttons.add(new CluuWindowButton({
            title: "Senden",
            click: async () => {
                await this.sendMailsAsync();

                await this.closeAsync();
            }
        }));
    }

    private sendMailsAsync() {
        Entities.Actions.SendAccountCredentialsInvokeAction.invokeAsync(
            {
                accountConstraint: this._accountConstraint?.toCql()
            },
            true
        );
    }
}
