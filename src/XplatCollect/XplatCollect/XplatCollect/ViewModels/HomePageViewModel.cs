using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using XplatCollect.Views;

namespace XplatCollect.ViewModels
{
    public sealed class HomePageViewModel : ViewModelBase
    {
        private string title;
        private string selectedCollectio;

        public HomePageViewModel(INavigationService navigationService
            , IPageDialogService pageDialogService) 
            : base(navigationService, pageDialogService)
        {
            ViewColletionCommand = new DelegateCommand(async () 
                =>await ExecuteViewColletionCommand());
        }

        public ICommand ViewColletionCommand { get; }

        public string Title {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string SeletedCollection
        {
            get => selectedCollectio;
            set => SetProperty(ref selectedCollectio, value);
        }

        private async Task ExecuteViewColletionCommand()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(AppConstants.ParametersKeys.COLLECTION_NAME
                ,SeletedCollection);

            await navigationService.NavigateAsync($"{nameof(CollectionPage)}", navigationParameters);

        }
    }
}
