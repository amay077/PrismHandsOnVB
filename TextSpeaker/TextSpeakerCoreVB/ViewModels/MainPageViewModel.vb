Imports Prism.Commands
Imports Prism.Navigation
Imports Prism.Services

Namespace ViewModels
    Public Class MainPageViewModel
        Implements IConfirmNavigationAsync

        Private ReadOnly _navigationService As INavigationService
        Private ReadOnly _pageDialogService As IPageDialogService

        Public ReadOnly Property NavigationCommand As DelegateCommand(Of String)
            Get
                Return New DelegateCommand(Of String)(AddressOf Navigate)
            End Get
        End Property

        Sub New(navigationService As INavigationService, pageDialogService As IPageDialogService)
            _navigationService = navigationService
            _pageDialogService = pageDialogService
        End Sub

        Private Sub Navigate(navigationPage As String)
            _navigationService.NavigateAsync(navigationPage)
        End Sub

        Public Sub OnNavigatedFrom(parameters As NavigationParameters) Implements INavigationAware.OnNavigatedFrom
        End Sub

        Public Sub OnNavigatedTo(parameters As NavigationParameters) Implements INavigationAware.OnNavigatedTo
        End Sub

        Public Async Function CanNavigateAsync(parameters As NavigationParameters) As Task(Of Boolean) Implements IConfirmNavigationAsync.CanNavigateAsync
            Return Await _pageDialogService.DisplayAlertAsync("確認", "Text Speech画面へ遷移しますか？", "OK", "Cancel")
        End Function
    End Class

End Namespace
