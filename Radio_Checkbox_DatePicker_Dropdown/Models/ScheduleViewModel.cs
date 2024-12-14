namespace Radio_Checkbox_DatePicker_Dropdown.Models
{
    public class ScheduleViewModel
    {
        public string SelectedPhysician { get; set; }
        public string SelectedProfession { get; set; }
        public bool IsMale { get; set; }
        public bool IsFemale { get; set; }
        public DateOnly SelectedDate { get; set; }

        public List<Physician> Physicians { get; set; }
        public List<Profession> Professions { get; set; }
    }
}
