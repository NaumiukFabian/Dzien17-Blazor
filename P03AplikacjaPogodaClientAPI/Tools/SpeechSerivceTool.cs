using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AplikacjaPogodaClientAPI.Tools
{
    public class SpeechSerivceTool
    {
        string apiKey;
        public SpeechSerivceTool()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<App>();
            //.SetBasePath(Directory.GetCurrentDirectory()) //odwołanie do pliku config
            //.AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            apiKey = configuration["speech_api_key"];
        }

        public async Task<string> RecognizeAsync()
        {
            var conf = SpeechConfig.FromSubscription(apiKey, "eastus");
            return await RecognizeFromMic(conf);
        }

        private async Task<string> RecognizeFromMic(SpeechConfig speechConfig)
        {
            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using var recognizer = new SpeechRecognizer(speechConfig, "pl-PL", audioConfig);

            var result = await recognizer.RecognizeOnceAsync();
            return result.Text;
        }
    }
}
