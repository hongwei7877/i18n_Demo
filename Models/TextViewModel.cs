using System.ComponentModel.DataAnnotations;

namespace i18n_Demo.Models {
    public class TextViewModel {
        [Display(Name = "Address", ResourceType = typeof(MultiLangResx.Resources.Resource))]
        public string Address { get; set; }

        [Display(Name = "Submit", ResourceType = typeof(MultiLangResx.Resources.Resource))]
        public string Submit { get; set; }

        [Display(Name = "CultureName", ResourceType = typeof(MultiLangResx.Resources.Resource))]
        public string Name { get; set; }
    }
}