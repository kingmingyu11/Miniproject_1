using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingBatteryMES.Models
{
    public class Order
    {
        private int id;
        private DateTime date;
        private string companyName;
        private int weight;
        private bool checking;

        [DisplayName("주문번호")]
        public int Id { get => id; set => id = value; }

        [DisplayName("날짜")]
        [Required(ErrorMessage = "날짜가 필요합니다.")]
        public DateTime Date { get => date; set => date = value; }

        [DisplayName("주문 회사 이름")]
        [Required(ErrorMessage = "화합물 이름이 필요합니다.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "화합물의 이름은 3 ~ 25 사이의 문자로 입력해주세요.")]
        public string CompanyName { get => companyName; set => companyName = value; }

        [DisplayName("주문 화합물 질량")]
        [Required(ErrorMessage = "화합물의 질량이 필요합니다.")]
        public int Weight { get => weight; set => weight = value; }

        [DisplayName("납부여부")]
        [Required(ErrorMessage = "확인이 필요합니다.")]
        public bool Checking { get => checking; set => checking = value; }
    }
}
