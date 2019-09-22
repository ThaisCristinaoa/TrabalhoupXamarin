using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Services;

namespace XplatCollect.ViewModels
{
    public sealed class CollectionPageViewModel : ViewModelBase
    {
        private string name;

        public CollectionPageViewModel(INavigationService navigationService
            , IPageDialogService pageDialogService) 
            : base(navigationService, pageDialogService)
        {
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public override Task InitializeAsync(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(AppConstants.ParametersKeys.COLLECTION_NAME))
            {
                Name = parameters.GetValue<string>(AppConstants.ParametersKeys.COLLECTION_NAME);
            }

            return base.InitializeAsync(parameters);
        }
    }
}
