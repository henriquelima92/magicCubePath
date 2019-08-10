public interface IInteractable
{
    bool IsInteractable { get; set; }
    bool IsSelected { get; set; }

    void DoInteraction();
    void ResetInteractable();
}
