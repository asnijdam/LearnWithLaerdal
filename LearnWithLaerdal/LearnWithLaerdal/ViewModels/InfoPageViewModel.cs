using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
//using System.Net.Mqtt;
using MQTTnet.Client;
using MQTTnet.Server;
//using Windows.UI.Core;
//using Windows.UI.Xaml;
//using Windows.UI.Xaml.Controls;
//using Threading.Tasks;




namespace LearnWithLaerdal.ViewModels
{
    public class InfoPageViewModel : BaseViewModel
    {
        public InfoPageViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://laerdal.com/"));
        }

        public ICommand OpenWebCommand { get; }

        private async void SendMQTT()
        {
            //creating new mtqq client
            var factory = new MQTTnet.MqttFactory();
            var mqttClient = factory.CreateMqttClient();

            // Create TCP based options using the builder.
            var options = new MQTTnet.Client.MqttClientOptionsBuilder()
                .WithClientId("Client1")
                .WithTcpServer("hip-doctor.cloudmqtt.com")
                .WithCredentials("FuzzyInterns", "wearesupersmart")
                .WithTls()
                .WithCleanSession()
                .Build();

            System.Threading.CancellationToken cancellationToken;
            await mqttClient.ConnectAsync(options, cancellationToken);

            var message = new MQTTnet.MqttApplicationMessageBuilder()
                .WithTopic("topic path")
                .WithPayload("1")
                .WithRetainFlag()
                .Build();

            await mqttClient.PublishAsync(message);

            // using System.Net.Mqtt; trenger denne pakken også
            //var configuration = new MqttConfiguration();
            //var mqttCredentials = new MqttClientCredentials("lwlApp","FuzzyInterns","wearesupersmart");


            //var client = await MqttClient.CreateAsync("hip-doctor.cloudmqtt.com",configuration);
            //var sessionState = await client.ConnectAsync(new `MqttClientCredentials`(clientId: "foo"), cleanSession: true);

            //client.SubscribeAsync("/simulator/cpu-module-BH108634/parameter/FEATURE_VocalSounds", MqttQualityOfService.AtMostOnce);
            //client.SubscribeAsync("/simulator/cpu-module-BH108634/parameter/EnableExternalLung", MqttQualityOfService.AtMostOnce);
            //client.SubscribeAsync("/simulator/cpu-module-BH108634/parameter/Cyanosis", MqttQualityOfService.AtMostOnce);


            // General info about mqtt cloud
            // host: 10.184.33.10    hip-doctor.cloudmqtt.com
            //simulator/cpu-module-BH108634/parameter/FEATURE_VocalSounds
            //simulator/cpu-module-BH108634/parameter/EnableExternalLung
            //simulator/cpu-module-BH108634/parameter/Cyanosis
        }
        private async void ReadMQTT()
        {
            //creating new mtqq client
            var factory = new MQTTnet.MqttFactory();
            var mqttClient = factory.CreateMqttClient();

            // Create TCP based options using the builder.
            var options = new MQTTnet.Client.MqttClientOptionsBuilder()
                .WithClientId("Client1")
                //.WithWebSocketServer("hip-doctor.cloudmqtt.com:1883/mqtt")
                .WithTcpServer("hip-doctor.cloudmqtt.com",1883)
                .WithCredentials("FuzzyInterns", "wearesupersmart")
                .WithTls()
                .WithCleanSession()
                .Build();

            System.Threading.CancellationToken cancellationToken;
            await mqttClient.ConnectAsync(options, cancellationToken);

            Console.WriteLine("### CONNECTED WITH SERVER ###");

            // Subscribe to a topic
            var subTopic1 = new MQTTnet.MqttTopicFilterBuilder()
                .WithTopic("/simulator/cpu-module-BH108634/parameter/FEATURE_VocalSounds")
                .Build();

            // Subscribe to a topic
            var subTopic2 = new MQTTnet.MqttTopicFilterBuilder()
                .WithTopic("/simulator/cpu-module-BH108634/parameter/EnableExternalLung")
                .Build();

            // Subscribe to a topic
            var subTopic3 = new MQTTnet.MqttTopicFilterBuilder()
                .WithTopic("/simulator/cpu-module-BH108634/parameter/Cyanosis")
                .Build();

            await mqttClient.SubscribeAsync(subTopic1);

            Console.WriteLine("### SUBSCRIBED ###");
            Console.WriteLine("### Current state: ###",subTopic1);

            // using System.Net.Mqtt; trenger denne pakken også
            //var configuration = new MqttConfiguration();
            //var mqttCredentials = new MqttClientCredentials("lwlApp","FuzzyInterns","wearesupersmart");


            //var client = await MqttClient.CreateAsync("hip-doctor.cloudmqtt.com",configuration);
            //var sessionState = await client.ConnectAsync(new `MqttClientCredentials`(clientId: "foo"), cleanSession: true);

            //client.SubscribeAsync("/simulator/cpu-module-BH108634/parameter/FEATURE_VocalSounds", MqttQualityOfService.AtMostOnce);
            //client.SubscribeAsync("/simulator/cpu-module-BH108634/parameter/EnableExternalLung", MqttQualityOfService.AtMostOnce);
            //client.SubscribeAsync("/simulator/cpu-module-BH108634/parameter/Cyanosis", MqttQualityOfService.AtMostOnce);


            // General info about mqtt cloud
            // host: 10.184.33.10    hip-doctor.cloudmqtt.com
            //simulator/cpu-module-BH108634/parameter/FEATURE_VocalSounds
            //simulator/cpu-module-BH108634/parameter/EnableExternalLung
            //simulator/cpu-module-BH108634/parameter/Cyanosis
        }

    }

}