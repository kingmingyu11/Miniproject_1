using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingBatteryMES.Models
{
    public class DailyOutput
    {
        private int id;
        private string name;
        private int weight;

        [DisplayName("화합물 ID")]
        public int Id { get => id; set => id = value; }

        [DisplayName("화합물 이름")]
        [Required(ErrorMessage = "화합물 이름이 필요합니다.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "화합물의 이름은 3 ~ 25 사이의 문자로 입력해주세요.")]
        public string Name { get => name; set => name = value; }

        [DisplayName("화합물 무게")]
        [Required(ErrorMessage = "화합물의 질량이 필요합니다.")]
        public int Weight { get => weight; set => weight = value; }
    }
}
