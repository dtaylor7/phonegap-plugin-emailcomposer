using System;
using System.Runtime.Serialization;
using Microsoft.Phone.Tasks;
using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;

namespace WPCordovaClassLib.Cordova.Commands
{
    [DataContract]
    public class Options
    {
        [DataMember]
        public string to;

        [DataMember]
        public string subject;

        [DataMember]
        public string body;
    }

    public class EmailComposer : BaseCommand
    {
        public void showEmailComposer(string options)
        {
            try
            {

                string[] inputs = JSON.JsonHelper.Deserialize<string[]>(options);
                Options opts = JSON.JsonHelper.Deserialize<Options>(inputs[0]);
                EmailComposeTask emailcomposer = new EmailComposeTask();
                emailcomposer.To = opts.to;
                emailcomposer.Subject = opts.subject;
                emailcomposer.Body = opts.body;
                emailcomposer.Show();
                DispatchCommandResult(new PluginResult(PluginResult.Status.OK));
            }
            catch (Exception e)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.JSON_EXCEPTION));
            }
        }
    }
}