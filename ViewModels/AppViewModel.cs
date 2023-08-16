using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTreeViewControl.ViewModels.Base;

namespace WpfTreeViewControl.ViewModels
{
    /// <summary>
    /// Implements an Application viewmodel that contains main viewmodel
    /// objects, commands, and properties.
    /// </summary>
    internal class AppViewModel : Base.BaseViewModel
    {
        private readonly BaseViewModel _GitHub = null;

        /// <summary>
        /// Class constructor
        /// </summary>
        public AppViewModel()
        {
           // _GitHub = new GitHubViewModel();

            // Adds a GitHubUser item and projects below it
          //  var root = new GitHubItemViewModel("Dirkster99", GitHubItemType.GitHubUser);
           // _GitHub.AddRoot(root);

           // var list = CreateTest.GetData();
           // list = CreateTest.GetDataMoreData(list);

           // foreach (var item in list)
           //     root.AddChildItem(new GitHubItemViewModel(item, GitHubItemType.GitHubProject));

            ////            root.Children.Sort(item => item.Name);
           // root.IsItemExpanded = true;
        }

        /// <summary>
        /// Gets a property that can be used to display
        /// a treeview on GitHub users and their projects.
        /// </summary>
        public BaseViewModel GitHub
        {
            get
            {
                return _GitHub;
            }
        }
    }
}
