using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;

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
        private static Windows.Media.SpeechRecognition.SpeechRecognizer speechRecognizer;
        private static IAsyncOperation<Windows.Media.SpeechRecognition.
            SpeechRecognitionResult> recognitionOperation;

        public static async System.Threading.Tasks.Task InitialiseSpeechRecognition()
        {
            // Create an instance of SpeechRecognizer.
            speechRecognizer = new Windows.Media.SpeechRecognition.SpeechRecognizer();

            // Add a web search grammar to the recognizer.
            var dictationGrammar = new Windows.Media.SpeechRecognition.
            SpeechRecognitionTopicConstraint(
              Windows.Media.SpeechRecognition.SpeechRecognitionScenario.Dictation,
              "dictation");


            speechRecognizer.Constraints.Add(dictationGrammar);

            // Compile the dictation grammar by default.
            await speechRecognizer.CompileConstraintsAsync();
        }
    }
}
