Imports Prism.Mvvm

Namespace Model
    Public Class Counter
        Inherits BindableBase
        Implements ICounter

        Private _value As Integer
        Public Property Value As Integer Implements ICounter.Value
            Get
                Return _value
            End Get
            Private Set(nValue As Integer)
                SetProperty(_value, nValue)
            End Set
        End Property

        Public Sub CountUp() Implements ICounter.CountUp
            Value = Value + 1
        End Sub
    End Class

End Namespace
