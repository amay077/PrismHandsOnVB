Namespace Model
    Public Interface ICounter
        Inherits INotifyPropertyChanged

        ReadOnly Property Value() As Integer

        Sub CountUp()
    End Interface

End Namespace
