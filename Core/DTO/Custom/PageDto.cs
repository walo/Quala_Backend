using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Custom
{
    public class PageDto
    {
        public int pageSize { get; set; }

        public int pageNumber { get; set; }

        public int totalElements { get; set; }

        public int totalPages
        {
            get { return pageNum(totalElements, pageSize); }
        }

        public PageDto GetPage(PageDto pageDto)
        {
            if (pageDto != null)
            {
                this.pageNumber = pageDto.pageNumber;
                this.pageSize = pageDto.pageSize;
            }
            else
            {
                this.pageNumber = 1;
                this.pageSize = 25;
            }
            return pageDto;
        }

        public PageDto setPage(PageDto pageDto)
        {
            PageDto pageDtoResponse = new PageDto();
            if (pageDto != null)
            {
                pageDtoResponse.pageNumber = pageDto.pageNumber > 0 ? pageDto.pageNumber : 1;
                pageDtoResponse.pageSize = pageDto.pageSize > 0 ? pageDto.pageSize : 25;
            }
            else
            {
                pageDtoResponse.pageNumber = 1;
                pageDtoResponse.pageSize = 25;
            }
            return pageDtoResponse;
        }

        private int pageNum(int totalElements, int pageSize)
        {
            int ret = 0; //variable retorno
            int res = 0; //variable residuo
            if (pageSize <= 0)
            {
                pageSize = 25;
            }
            if (totalElements > 0)
            {
                if (totalElements >= pageSize)
                {
                    ret = (totalElements / pageSize);
                    res = totalElements %= pageSize;
                    if (res > 0)
                    {
                        ret += 1;
                    }
                }
                else
                {
                    ret = 1;
                }
            }
            else
            {
                ret = 0;
            }
            return ret;
        }
    }
}
