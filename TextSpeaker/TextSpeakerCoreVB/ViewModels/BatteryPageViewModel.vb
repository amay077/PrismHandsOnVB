Imports Plugin.Battery.Abstractions
Imports Prism.Mvvm

Namespace ViewModels

    Public Class BatteryPageViewModel
        Inherits BindableBase

        Private WithEvents  _battery as IBattery
        Private _status As BatteryStatus

        Public Property Status() As BatteryStatus
            Get
                Return _status
            End Get
            Set(value As BatteryStatus)
                SetProperty(_status, value)
            End Set
        End Property

        Private _remainingChargePercent As Integer

        Public Property RemainingChargePercent() As Integer
            Get
                Return _remainingChargePercent
            End Get
            Set(value As Integer)
                SetProperty(_remainingChargePercent, value)
            End Set
        End Property

        Public Sub New(battery As IBattery)
            _battery = battery
            Status = _battery.Status
            RemainingChargePercent = _battery.RemainingChargePercent
        End Sub

        Private Sub Battery_BatteryChanged(sender As Object, args As BatteryChangedEventArgs) Handles _battery.BatteryChanged
            Status = args.Status
            RemainingChargePercent = args.RemainingChargePercent
        End Sub

    End Class
End Namespace
