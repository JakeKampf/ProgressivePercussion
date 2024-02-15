namespace ProgressivePercussion.ViewModels
{
   public interface IMainWindowViewModel
   {
      public string ExerciseName { get; }
      public string ExerciseTempo { get; set; }
      public string NumberOfMeasures { get; }
    }
}
