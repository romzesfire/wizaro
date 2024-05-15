namespace Magic.DTO.Model;

public class PaginationModel
{
    public PaginationModel(int selectedPage, List<int> pages)
    {
        Pages = pages;
        SelectedPage = selectedPage;
    }

    public IList<int> Pages { get; set; }
    public int SelectedPage { get; set; }
}