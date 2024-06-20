using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cluu.Client.Mail;

namespace SwhOnlineStreamingServiceManagement.Tests.Services
{
    internal class MockCluuMailManager : ICluuMailManager
    {
        private readonly List<CluuMail> mails;

        public MockCluuMailManager()
        {
            this.mails = new List<CluuMail>();
        }

        public IReadOnlyList<CluuMail> Mails => this.mails;

        Task ICluuMailManager.SendMailAsync(CluuMail cluuMail, CancellationToken cancellationToken)
        {
            this.mails.Add(cluuMail);

            return Task.CompletedTask;
        }

        Task ICluuMailManager.SendMailAsync(CluuMail cluuMail, int? smtpServerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
