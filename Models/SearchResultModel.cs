using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SearchResultModel<T>
    {
        private ObservableCollection<T> resultList;

        public int TotalCount { get; set; }
        public ObservableCollection<T> ResultList
        {
            get
            {
                return resultList ?? new ObservableCollection<T>();
            }
            set
            {
                resultList = value;
            }
        }
    }
}
