using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace Checkers_2._0
{
    public class SpeechHelper
    {
        public static void HandleSpeechCommand(IActivatedEventArgs args)
        {
            var commandArgs = args as
          Windows.ApplicationModel.Activation.VoiceCommandActivatedEventArgs;
            Windows.Media.SpeechRecognition.SpeechRecognitionResult
          speechRecognitionResult = commandArgs.Result;

            string textSpoken = speechRecognitionResult.Text;

            CortanaInterop.CortanaText = textSpoken;
        }
    }
}
