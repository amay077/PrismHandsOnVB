Imports Plugin.Battery
Imports Plugin.Battery.Abstractions

Namespace Model
    Public Class Battery
        Implements IBattery

        Public Event BatteryChanged As BatteryChangedEventHandler Implements IBattery.BatteryChanged

        Private WithEvents _battery As IBattery

        Public ReadOnly Property RemainingChargePercent As Integer Implements IBattery.RemainingChargePercent
            Get
                Return _battery.RemainingChargePercent
            End Get
        End Property

        Public ReadOnly Property Status As BatteryStatus Implements IBattery.Status
            Get
                Return _battery.Status
            End Get
        End Property

        Public ReadOnly Property PowerSource As PowerSource Implements IBattery.PowerSource
            Get
                Return _battery.PowerSource
            End Get
        End Property

        Sub New()
            _battery = CrossBattery.Current
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            _battery.Dispose()
        End Sub

        Private Sub OnBatteryChanged(sender As Object, args As BatteryChangedEventArgs) Handles _battery.BatteryChanged
            RaiseEvent BatteryChanged(Me, args)
        End Sub

    End Class

End Namespace
