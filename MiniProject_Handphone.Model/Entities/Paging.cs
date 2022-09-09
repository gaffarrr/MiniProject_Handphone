using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Handphone.Model.Entities
{
    public class Paging<T> where T : class
    {
        public int TotalRecords { get; set; }
        public int CurrentPageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPrevPage { get; set; }
        public T Data { get; set; }
        public Paging(T data, int totalRecords, int currentPageNumber, int pageSize)
        {
            Data = data;
            TotalRecords = totalRecords;
            CurrentPageNumber = currentPageNumber;
            PageSize = pageSize;

            //total pages count
            TotalPages = Convert.ToInt32(Math.Ceiling((double)TotalRecords / (double)pageSize));

            HasNextPage = CurrentPageNumber < TotalPages;
            HasPrevPage = CurrentPageNumber > 1;
        }
    }
}
