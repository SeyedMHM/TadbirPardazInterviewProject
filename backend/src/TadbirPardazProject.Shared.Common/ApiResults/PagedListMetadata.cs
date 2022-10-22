﻿namespace TadbirPardazProject.Shared.Common.ApiResults
{
    public class PagedListMetadata
    {
        private int _maxPageSize = 50;
        private int _defaultPageSize = 5;
        private int _minPageSize = 1;

        private int _pageSize;
        public int PageSize
        {
            get
            {
                if (_pageSize > _maxPageSize)
                {
                    _pageSize = _maxPageSize;
                }
                else if (_pageSize == 0)
                {
                    _pageSize = _defaultPageSize;
                }
                else if (_pageSize < _minPageSize)
                {
                    _pageSize = _minPageSize;
                }
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }

        private int _pageId;
        public int PageId
        {
            get
            {
                if (_pageId < 1)
                {
                    _pageId = 1;
                }
                return _pageId;
            }
            set
            {
                _pageId = value;
            }
        }
    }
}
