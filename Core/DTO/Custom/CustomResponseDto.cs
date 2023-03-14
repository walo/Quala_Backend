using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Custom
{
    public class CustomResponseDto<T> : PageDto
    {
        public CustomResponseDto(T data)
        {
            Data = data;
        }
        public bool Successful { get; set; }
        public string Message { get; set; }
        public int Count { get; set; }
        public T Data { get; set; }
        public List<CustomResponseDtoDetail> Detail { get; set; }
    }

    public class CustomResponseDtoDetail
    {
        public string Message { get; set; }
    }
}
