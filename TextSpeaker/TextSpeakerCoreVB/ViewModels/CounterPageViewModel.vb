Imports Prism.Commands
Imports Prism.Mvvm
Imports TextSpeaker.Model

Namespace ViewModels
    Public Class CounterPageViewModel
        Inherits BindableBase

        Private WithEvents _counter As ICounter
        Private _value As Integer

        Public Property Value() As Integer
            Get
                Return _value
            End Get
            Set(nValue As Integer)
                SetProperty(_value, nValue)
            End Set
        End Property

        Public ReadOnly Property CountUpCommand() As DelegateCommand
            Get
                Return New DelegateCommand(Sub() _counter.CountUp())
            End Get
        End Property

        Sub New(counter As ICounter)
            _counter = counter
        End Sub

        Private Sub Counter_PropertyChanged(sender As Object, args As PropertyChangedEventArgs) Handles _counter.PropertyChanged
            If args.PropertyName = "Value" Then
                Value = _counter.Value
            End If
        End Sub

    End Class

End Namespace
