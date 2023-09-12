using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecyclingBatteryMES.Models;
using RecyclingBatteryMES.Repositories;
using RecyclingBatteryMES.Presenters;
using RecyclingBatteryMES.Views;
using System.Windows.Forms;

namespace RecyclingBatteryMES.Presenters
{
    public class DashBoardPresenter
    {
        // 필드
        private ICompoundRepository compoundRepository;
        private IOrderRepository orderRepository;
        private IDailyOutputRepository outputRepository;
        private IDashboardView view;
        private BindingSource resourceBindingSource;
        private IEnumerable<Compound> compoundList;

        // 이벤트 등록
        private void AddEvents()
        {
            view.OnDisplay += OnDisplay;
        }

        public void OnDisplay(object sender, EventArgs e)
        {
            MessageBox.Show("동작!!");

            LoadAllCompoundList();
            this.view.SetResourceListBindSource(resourceBindingSource);
        }

        private void TestMethod(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
        // 생성자
        public DashBoardPresenter(IDashboardView view, ICompoundRepository repository)
        {
            this.resourceBindingSource = new BindingSource();
            this.view = view;
            this.compoundRepository = repository;
            // 핸들러 등록
            AddEvents();
            // 바인딩 소스 세팅
            this.view.SetResourceListBindSource(resourceBindingSource);
            // 컴파운드 리스트 뷰에 올리기
            LoadAllCompoundList();
      
        }

        private void LoadAllCompoundList()
        {
            compoundList = compoundRepository.GetAll();
            resourceBindingSource.DataSource = compoundList;
        }
    }
}
