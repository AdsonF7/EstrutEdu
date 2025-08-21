using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
    public List<string> _items = new List<string>();
    public int _margin = 20;
    public int _padding = 10;
    public int _maxItems = 4;
    private int _scroll = 0;
    private Sprite[] _sprites;
    private Button[] _bt_moves = new Button[2];
    private Button[] _bt_items;
    private int[] _indexes;
    private Dictionary<string, UnityAction> _actions;
    public int Margin
    {
        get { return _margin; }
        set { _margin = value; }
    }

    public int Padding
    {
        get { return _padding; }
        set { _padding = value; }
    }

    public int MaxItems
    {
        get { return _maxItems; }
        set { _maxItems = value; }
    }

    public List<string> Items
    {
        get { return _items; }
        set { _items = value; }
    }

    private int GetFakeCount()
    {
        if (HasScroll()) return _maxItems + 1;
        return _maxItems;
    }

    private bool HasScroll()
    {
        if (_items.Count > _maxItems) return true;
        return false;
    }

    private float GetSizeRect()
    {
        int width = Screen.width - (_margin * 2);
        int height = Screen.height - (_margin * 2);
        int[] size = (height > width) ? new int[] { height, width } : new int[] { width, height };
        float l = size[0] / GetFakeCount() - _padding;
        if (l > size[1]) l = size[1];
        return l;
    }

    private int GetMaxScroll()
    {
        return _items.Count - _maxItems;
    }

    private void ScrollUp()
    {
        if (_scroll < _items.Count - _maxItems)
        {
            _scroll += 1;
            if (_scroll == 1) _bt_moves[0].interactable = true;
            if (_scroll == _items.Count - _maxItems) _bt_moves[1].interactable = false;
            _indexes = Enumerable.Range(_scroll, _maxItems).ToArray();
            RefreshScroll();
        }
    }

    private void ScrollDown()
    {
        if (_scroll > 0)
        {
            _scroll -= 1;
            if (_scroll == 0) _bt_moves[0].interactable = false;
            if (_scroll == _items.Count - _maxItems - 1) _bt_moves[1].interactable = true;
            _indexes = Enumerable.Range(_scroll, _maxItems).ToArray();
            RefreshScroll();
        }

    }

    private void RefreshScroll()
    {
        for (int i = 0; i < _bt_items.Length; i++) _bt_items[i].gameObject.SetActive(false);
        for (int i = 0; i < _indexes.Length; i++)
        {
            Button bt_item = _bt_items[_indexes[i]];
            bt_item.image.rectTransform.localPosition = GetPositions()[i];
            bt_item.gameObject.SetActive(true);
        }
    }

    private Vector3[] GetPositions()
    {
        Vector3[] positions = new Vector3[_maxItems];
        float lengthFirstCenterToLastCenter = GetSizeRect() * (_maxItems - 1) + _padding * (_maxItems - 1);
        float ratio = lengthFirstCenterToLastCenter / (_maxItems - 1);
        float start = -lengthFirstCenterToLastCenter / 2;
        for (int i = 0; i < _maxItems; i++) positions[i] = new Vector3(start + ratio * i, 0);
        return positions;
    }
    private Button AddButton(string name, Vector2 size)
    {
        Sprites names = GetNames(name);
        SpriteState ss = new SpriteState();
        ss.highlightedSprite = names.highlighted;
        ss.pressedSprite = names.pressed;
        ss.selectedSprite = names.selected;
        ss.disabledSprite = names.disabled;
        GameObject bt_go = new GameObject();
        bt_go.name = $"bt_{name}";
        bt_go.transform.SetParent(gameObject.transform);
        bt_go.transform.localScale = Vector3.one;
        bt_go.transform.localPosition = Vector3.zero;
        bt_go.transform.localRotation = Quaternion.Euler(0, 0, 0);
        Image bt_go_image = bt_go.AddComponent<Image>();
        Button bt_go_button = bt_go.AddComponent<Button>();
        bt_go_image.rectTransform.sizeDelta = size;
        bt_go_image.rectTransform.localPosition = Vector3.zero;
        bt_go_image.sprite = names.standard;
        bt_go_button.transition = Selectable.Transition.SpriteSwap;
        bt_go_button.spriteState = ss;
        return bt_go_button;
    }
    private Button AddButton(string name, Vector2 size, Vector3 localPosition)
    {
        Sprites names = GetNames(name);
        SpriteState ss = new SpriteState();
        ss.highlightedSprite = names.highlighted;
        ss.pressedSprite = names.pressed;
        ss.selectedSprite = names.selected;
        ss.disabledSprite = names.disabled;
        GameObject bt_go = new GameObject();
        bt_go.name = $"bt_{name}";
        bt_go.transform.SetParent(gameObject.transform);
        bt_go.transform.localScale = Vector3.one;
        bt_go.transform.localPosition = Vector3.zero;
        bt_go.transform.localRotation = Quaternion.Euler(0, 0, 0);
        Image bt_go_image = bt_go.AddComponent<Image>();
        Button bt_go_button = bt_go.AddComponent<Button>();
        bt_go_image.rectTransform.sizeDelta = size;
        bt_go_image.rectTransform.localPosition = localPosition;
        bt_go_image.sprite = names.standard;
        bt_go_button.transition = Selectable.Transition.SpriteSwap;
        bt_go_button.spriteState = ss;
        return bt_go_button;
    }

    private Sprites GetNames(string name)
    {
        Sprites sn = new Sprites();
        sn.pressed = this._sprites.First(x => x.name == $"bt_{name}_press");
        sn.highlighted = this._sprites.First(x => x.name == $"bt_{name}_high");
        sn.selected = this._sprites.First(x => x.name == $"bt_{name}_select");
        sn.standard = this._sprites.First(x => x.name == $"bt_{name}");
        sn.disabled = this._sprites.First(x => x.name == $"bt_{name}_disabled");
        return sn;
    }

    private void bt_Torcao()
    {

    }

    private void bt_Compressao()
    {

    }

    private void bt_Tracao()
    {

    }

    private void bt_Flambagem()
    {

    }

    private void btTracaoCompressao()
    {

    }

    private Dictionary<string, UnityAction> GetFunctions(string name)
    {
        return new Dictionary<string, UnityAction> {
            {"torcao", this.bt_Torcao}
        };
    }

    
    void Start()
    {
        _actions = new Dictionary<string, UnityAction> 
        { 
            {"torcao", this.bt_Torcao},
            {"compressao", this.bt_Compressao},
            {"tracao", this.bt_Tracao},
            {"flambagem", this.bt_Flambagem},
            {"tracaocompressao", this.btTracaoCompressao}
        };
        _indexes = Enumerable.Range(_scroll, _maxItems).ToArray();
        _bt_items = new Button[_items.Count];
        float wh = GetSizeRect();
        this._sprites = Resources.LoadAll<Sprite>("buttons_menu");
        
        if (HasScroll())
        {
            float btMoveWidth = wh / 2;
            float posBtMove = Screen.width / 2 - btMoveWidth / 2 - _margin;
            Button go_left = AddButton("left", new Vector2(btMoveWidth, wh), new Vector3(-posBtMove, 0, 0));
            Button go_right = AddButton("right", new Vector2(btMoveWidth, wh), new Vector3(posBtMove, 0, 0));
            _bt_moves[0] = (go_left);
            _bt_moves[1] = (go_right);
            go_left.onClick.AddListener(ScrollDown);
            go_right.onClick.AddListener(ScrollUp);
            if (_scroll == 0) go_left.interactable = false;
            else if (_scroll == _items.Count - _maxItems) go_right.interactable = false;
        }
        for (int i = 0; i < _items.Count; i++)
        {
            Button _bt_item = AddButton(_items[i], new Vector2(wh, wh));
            _bt_item.gameObject.SetActive(false);
            _bt_item.onClick.AddListener(_actions[_items[i]]);
            _bt_items[i] =_bt_item;

        }
        RefreshScroll();
    }


    // Update is called once per frame
    void Update()
    {

    }


}

class Sprites
{
    public Sprite highlighted { get; set; }
    public Sprite pressed { get; set; }
    public Sprite selected { get; set; }
    public Sprite disabled { get; set; }
    public Sprite standard { get; set; }
}
