/* tslint:disable */
/* eslint-disable */
// Cluu Version: 6.3.1

// @ts-ignore
import { CluuFieldSelector, CluuController, CluuDateTime } from "cluu";

export namespace SwhOnlineStreamingServiceManagement {
    // FieldSelection for SwhOnlineStreamingServiceManagement
    export namespace FieldSelection
    {
        /**
         * Field selector for SwhOnlineStreamingServiceManagement.Account
         */
        export class Account extends CluuFieldSelector {
            /** 
             * This method returns fieldselector for this class.
             * @returns A new instance of CluuMetadata.FieldSelection.AppModel.
             */
            public static createFieldSelector(): Account {
                return new Account();
            }

            /** 
             * This method returns the cluuClassName of the generated fieldSelector.
             * @returns The value 'SwhOnlineStreamingServiceManagement.Account'.
             */
            public getCluuClassName(): string {
                return "SwhOnlineStreamingServiceManagement.Account";
            }

            /**
             * Accounttyp ID
             */
            public get AccountTypeId(): string {
                return this.getFieldName("AccountTypeId");
            }

            /**
             * Bezeichnung
             */
            public get Caption(): string {
                return this.getFieldName("Caption");
            }

            /**
             * Beschreibung
             */
            public get Description(): string {
                return this.getFieldName("Description");
            }

            /**
             * ID
             */
            public get Id(): string {
                return this.getFieldName("Id");
            }

            /**
             * Passwort
             */
            public get Password(): string {
                return this.getFieldName("Password");
            }

            /**
             * Verantwortliche Person ID
             */
            public get ResponsiblePersonId(): string {
                return this.getFieldName("ResponsiblePersonId");
            }

            /**
             * Abomodell ID
             */
            public get SubscriptionModelId(): string {
                return this.getFieldName("SubscriptionModelId");
            }

            /**
             * Benutzername
             */
            public get Username(): string {
                return this.getFieldName("Username");
            }
        }
    }

    export namespace Actions {
        /**
         * Zugangsdaten als EMail versenden
         */
        export class SendAccountCredentialsInvokeAction {
            /**
             * Gets the action name.
             */
            public static get actionName(): string {
                return "SwhOnlineStreamingServiceManagement.AddIns.Notifications.SendAccountCredentials";
            }
            
            /**
             * Gets whether the action has a request message.
             */
            public static get hasRequestMessage(): boolean {
                return true;
            }

            /**
             * Gets whether the action has a response message.
             */
            public static get hasResponseMessage(): boolean {
                return false;
            }

            /**
             * Invokes the action.
             * @param isSilent [true] if the call should display no loading indicator. Use [true] for background tasks.
             */
            public static async invokeAsync(request: SendAccountCredentialsInvokeRequest, isSilent: boolean = false, abortSignal?: AbortSignal): Promise<void> {
                return await CluuController.invokeAsync({ actionInvokeInfo: SendAccountCredentialsInvokeAction, message: request, isSilent, abortSignal});
            }
        }

        export interface SendAccountCredentialsInvokeRequest {
            accountConstraint: string;
        }

    }
}

/* eslint-enable */
/* tslint:enable */
