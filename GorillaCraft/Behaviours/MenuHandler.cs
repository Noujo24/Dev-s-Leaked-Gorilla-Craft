﻿using GorillaCraft.Behaviours.UI;
using GorillaCraft.Extensions;
using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace GorillaCraft.Behaviours
{
    public class MenuHandler : MonoBehaviour
    {
        public static bool IsViewingMenuList;

        public AssetLoader AssetLoader;
        public PlacementHelper Placement;
        public Configuration Config;

        public Transform UIParent;
        public Transform ModelParent;

        private Text _currentItemText;
        private Image _currentItemImage;
        private List<Button_Item> _blockItemList;
        private Dictionary<Button_Item, int> _blockItemCollection;

        private MenuObject _mainMenuObject;
        private Input_Slider _blockSlider;
        private Button_Page _leftButton, _rightButton;
        private List<MenuObject> _menuObjectList;
        private int _currentItemIndex = 0, _currentMenuIndex = 0;

        public Vector3 LeftPosition = new(-0.0929f, 0.1055f, 0.0141f), LeftEuler = new(-10.992f, 85.797f, 74.78f);

        public void Start()
        {
            transform.localPosition = LeftPosition;
            transform.localEulerAngles = LeftEuler;
            transform.localScale = Vector3.one * 1.146174f;

            UIParent = transform.Find("UI Parent");
            ModelParent = transform.Find("Menu Parent");

            _leftButton = transform.Find("UI Parent/Next Page").AddComponent<Button_Page>();
            _leftButton.menuParent = this;
            _leftButton.buttonType = Button_Page.ButtonType.Left;

            _rightButton = transform.Find("UI Parent/Previous Page").AddComponent<Button_Page>();
            _rightButton.menuParent = this;
            _rightButton.buttonType = Button_Page.ButtonType.Right;

            _blockSlider = transform.Find("UI Parent/Scroll Bar").AddComponent<Input_Slider>();
            _blockSlider.MenuParent = this;
            _blockSlider.Split = 14;
            _blockSlider.SliderData = new ButtonSliderData()
            {
                Least = 0f,
                Greatest = 14
            };
            _blockSlider.OptionData = new ButtonOptionData<float>();

            Button_Page settingsButton = transform.Find("UI Parent/Settings Button").AddComponent<Button_Page>();
            settingsButton.menuParent = this;
            settingsButton.buttonType = Button_Page.ButtonType.SettingToggle;

            #region Item initialization

            _blockItemList = [];
            _blockItemCollection = [];

            Transform blockPageParent = transform.Find(Constants.PageGridName);
            for (int i = 0; i < blockPageParent.childCount; i++)
            {
                var blockPageObject = blockPageParent.GetChild(i);
                Button_Item blockPageItem = blockPageObject.AddComponent<Button_Item>();

                blockPageItem.menuParent = this;
                _blockItemList.Add(blockPageItem);
                _blockItemCollection.Add(blockPageItem, i);
            }

            _currentItemText = transform.Find(Constants.CurrentItemName).GetComponent<Text>();
            _currentItemImage = transform.Find(Constants.CurrentItemImage).GetComponent<Image>();

            RedrawItems();

            #endregion

            #region Menu object initialization

            _mainMenuObject = new MenuObject()
            {
                Alias = "Default",
                MenuName = "Menu 1",
                PageName = "Main Page"
            };

            _menuObjectList =
            [
                new MenuObject()
                {
                    Alias = "Settings",
                    MenuName = "Menu 2",
                    PageName = "Settings Page"
                },
                new MenuObject()
                {
                    Alias = "Credits",
                    MenuName = "Menu 2",
                    PageName = "Credit Page"
                }
            ];

            RedrawMenus();

            #endregion

            Input_Checkbox darkModeButton = transform.Find("UI Parent/Pages/Settings Page/DarkMode").AddComponent<Input_Checkbox>();
            darkModeButton.MenuParent = this;
            darkModeButton.OptionData = new ButtonOptionData<bool>()
            {
                Name = "Dark Mode",
                Value = Config.DarkMode.Value,
                OnOptionSet = (value) =>
                {
                    Config.DarkMode.Value = value;
                    Shader.SetGlobalInt("_DarkEnabled", value ? 1 : 0);
                }
            };

            Input_Slider slider_BlockResource = transform.Find("UI Parent/Pages/Settings Page/BlockResourceSlider").AddComponent<Input_Slider>();
            slider_BlockResource.MenuParent = this;
            slider_BlockResource.Split = 2;
            slider_BlockResource.SliderData = new ButtonSliderData()
            {
                Least = 0f,
                Greatest = 2f
            };
            slider_BlockResource.SliderContentOverride = new Dictionary<float, string>()
            {
                { 0, "Vanilla" }, { 1, "Classic" }, { 2, "Faithful"}
            };
            slider_BlockResource.OptionData = new ButtonOptionData<float>()
            {
                Name = "Block Textures",
                Value = 0,
                OnOptionSet = (value) =>
                {
                    Shader.SetGlobalFloat("_MapIndex", value);
                }
            };

            Input_Slider placeButton = transform.Find("UI Parent/Pages/Settings Page/PlaceBreak Volume").AddComponent<Input_Slider>();
            placeButton.MenuParent = this;
            placeButton.Split = 25;
            placeButton.SliderData = new ButtonSliderData()
            {
                Least = 0f,
                Greatest = 100f,
                Prefix = "%"
            };
            placeButton.OptionData = new ButtonOptionData<float>()
            {
                Name = "Place/Break Volume",
                Value = Config.PlaceBreakVolume.Value,
                OnOptionSet = (value) =>
                {
                    Config.PlaceBreakVolume.Value = Mathf.RoundToInt(value);
                }
            };

            Input_Slider stepButton = transform.Find("UI Parent/Pages/Settings Page/Footstep Volume").AddComponent<Input_Slider>();
            stepButton.MenuParent = this;
            stepButton.Split = 25;
            stepButton.SliderData = new ButtonSliderData()
            {
                Least = 0f,
                Greatest = 100f,
                Prefix = "%"
            };
            stepButton.OptionData = new ButtonOptionData<float>()
            {
                Name = "Footstep Volume",
                Value = Config.FootstepVolume.Value,
                OnOptionSet = (value) =>
                {
                    Config.FootstepVolume.Value = Mathf.RoundToInt(value);
                }
            };
        }

        private void RedrawItems()
        {
            try
            {
                int w = 8, h = 5, t = -w * _currentItemIndex;

                for (int i = 0; i < _blockItemList.Count; i++)
                {
                    t++;
                    bool e = t <= w * h && t >= (_currentItemIndex == 0 ? 0 : 1);
                    Button_Item currentItem = _blockItemList[i];

                    currentItem.gameObject.SetActive(e);
                }
            }
            catch (Exception exception)
            {
                Logging.Log(exception.String(), BepInEx.Logging.LogLevel.Error);
            }
        }

        private void RedrawMenus()
        {
            MenuObject currentMenu = IsViewingMenuList ? _menuObjectList[_currentMenuIndex] : _mainMenuObject;
            (int menuCode, int uiCode) = currentMenu.GetMenuHashCodes(gameObject);
            IEnumerable<MenuObject> menuCollection = new List<MenuObject>(_menuObjectList).Append(_mainMenuObject);

            foreach (MenuObject menu in menuCollection)
            {
                (GameObject menuObject, GameObject uiObject) = menu.GetMenuObject(gameObject);

                menuObject.SetActive(menuObject.GetHashCode() == menuCode);
                uiObject.SetActive(uiObject.GetHashCode() == uiCode);
            }

            _leftButton.gameObject.SetActive(IsViewingMenuList);
            _rightButton.gameObject.SetActive(IsViewingMenuList);
            _blockSlider.gameObject.SetActive(!IsViewingMenuList);
            _currentItemImage.transform.parent.gameObject.SetActive(!IsViewingMenuList);
            _currentItemText.text = IsViewingMenuList ? currentMenu.Alias : Placement.GetBlock().BlockDefinition;
        }

        public void BlockItemPress(Button_Item sender)
        {
            AudioSource source = GetComponent<AudioSource>();

            source.PlayOneShot(source.clip);

            IBlock _newBlock = Placement.SetBlock(_blockItemCollection[sender]);

            _currentItemText.text = _newBlock.BlockDefinition;
            _currentItemImage.sprite = sender.GetComponent<Image>().sprite;
            _currentItemImage.color = sender.GetComponent<Image>().color;
        }

        public async void PageItemPress(Button_Page sender)
        {
            if (sender.buttonType != Button_Page.ButtonType.SettingToggle)
            {
                AudioSource source = GetComponent<AudioSource>();

                source.PlayOneShot(source.clip);

                int increment = sender.buttonType == Button_Page.ButtonType.Right ? -1 : 1;
                _currentMenuIndex = Mathf.Clamp(_currentMenuIndex + increment, 0, _menuObjectList.Count - 1);

                RedrawMenus();
            }
            else
            {

                if (sender.name == "Settings Button")
                {
                    Transform lever = sender.transform.Find("Lever");

                    lever.localScale = new Vector3(lever.localScale.x, lever.localScale.y, -lever.localScale.z);
                    lever.localPosition = new Vector3(lever.localPosition.x, -lever.localPosition.y, lever.localPosition.z);

                    sender.TryGetComponent(out AudioSource source);

                    source.PlayOneShot(IsViewingMenuList ? await AssetLoader.LoadAsset<AudioClip>("Lever2") : await AssetLoader.LoadAsset<AudioClip>("Lever1"));
                }
                else
                {
                    AudioSource source = GetComponent<AudioSource>();

                    source.PlayOneShot(source.clip);
                }

                IsViewingMenuList ^= true;

                RedrawMenus();
            }
        }

        public void SettingButtonPress(Input_Checkbox radio, bool select)
        {
            if (select)
            {
                AudioSource source = GetComponent<AudioSource>();

                source.PlayOneShot(source.clip);
                radio.OptionData.OnOptionSet.Invoke(radio.OptionData.Value);
            }
        }

        public void SettingButtonPress(Input_Slider slider, bool select)
        {
            if (select && slider == _blockSlider)
            {
                _currentItemIndex = Mathf.FloorToInt(slider.SliderData.GetValue(slider.OptionData.Value));

                RedrawItems();
            }
            else if (select && slider != _blockSlider)
            {
                slider.OptionData.OnOptionSet.Invoke(slider.SliderData.GetValue(slider.OptionData.Value));
            }
            else
            {
                AudioSource source = GetComponent<AudioSource>();

                source.PlayOneShot(source.clip);
            }
        }
    }
}
