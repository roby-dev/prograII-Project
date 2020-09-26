using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using RelojCliente.Entidad;

namespace RelojCliente.Negocios
{
    class ClsNsms
    {
        internal void MtdMandarMensaje(ClsEsms objEM)
        {
            // Find your Account Sid and Token at twilio.com/console
            // DANGER! This is insecure. See http://twil.io/secure
            const string accountSid = "AC72d1caba6c35a29cd4c4d7a8542ecbab";
            const string authToken = "931747fa507ead487b4cfde14370e479";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: objEM.Mensaje,
                from: new Twilio.Types.PhoneNumber("++12053950636"),
                to: new Twilio.Types.PhoneNumber("+51928482892")
            );
        }
    }
}
