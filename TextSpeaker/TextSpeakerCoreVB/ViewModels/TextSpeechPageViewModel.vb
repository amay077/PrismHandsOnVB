Imports System.Windows.Input
Imports Prism.Commands
Imports TextSpeaker.Model

Namespace ViewModels

    Public Class TextSpeechPageViewModel

        Public Property Text() As String = "Hello, World."

        Public ReadOnly Property SpeechCommand() As ICommand = New DelegateCommand(AddressOf Speech)

        Private ReadOnly _textToSpeechService As ITextToSpeechService

        Public Sub New(textToSpeechService As ITextToSpeechService)
            _textToSpeechService = textToSpeechService
        End Sub

        Public Sub Speech()
            _textToSpeechService.Speech(Text)
        End Sub

    End Class
End Namespace
