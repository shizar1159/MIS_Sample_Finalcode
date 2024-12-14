namespace Radio_Checkbox_DatePicker_Dropdown.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string SelectedPhysician { get; set; }
        public string SelectedProfession { get; set; }
        public bool IsMale { get; set; }
        public bool IsFemale { get; set; }
        public DateTime SelectedDate { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
