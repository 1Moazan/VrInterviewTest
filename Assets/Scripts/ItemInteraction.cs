using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject[] instruments;
    [SerializeField] private UIController uiController;
    [SerializeField] private MeshRenderer sphereRenderer;

    private void OnEnable()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            var i1 = i;
            uiController.SetWeaponAction(i , ()=>SetItem(Category.Weapon , i1));
        }
        
        for (int i = 0; i < instruments.Length; i++)
        {
            var i1 = i;
            uiController.SetInstrumentAction(i , ()=>SetItem(Category.Instrument , i1));
        }
    }

    public void TurnOffItems()
    {
        sphereRenderer.enabled = false;
        foreach (GameObject instrument in instruments)
        {
            instrument.SetActive(false);
        }

        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
    }

    public void SetItem(Category category, int index)
    {
        TurnOffItems();
        switch (category)
        {
            case Category.Weapon:
                weapons[index].SetActive(true);
                break;
            case Category.Instrument:
                instruments[index].SetActive(true);
                break;
        }
    }

    public enum Category
    {
        Weapon,
        Instrument
    }

}
