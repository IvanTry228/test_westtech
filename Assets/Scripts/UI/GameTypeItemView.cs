using Client.DTO;
using TMPro;
using UnityEngine;

public class GameTypeItemView : BaeItemView<GamesTypesDTO>
{
    [SerializeField]
    private TMP_Text title;

    [SerializeField]
    private TMP_Text description;

    public override void SetupContent(GamesTypesDTO content)
    {
        base.SetupContent(content);
        title.SetText(content.Title);
        description.SetText(content.Description);
    }
}
