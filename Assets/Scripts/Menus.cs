using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Menus : MonoBehaviour
{

    private enum MenuType { Construction, Detection, Offer, None }

    [SerializeField] private Animator tableAnimator;

    [SerializeField] private Menu constructionMenu;
    [SerializeField] private Menu detectionMenu;
    [SerializeField] private Menu offersMenu;

    [SerializeField] private Button constructionButton;
    [SerializeField] private Button detectionButton;
    [SerializeField] private Button offersButton;

    private MenuType currentMenuType = MenuType.None;

    private bool waitingForMenuToClose;

    public Action OnMenuClosed;

    public void InitializeMenus(Action<int, string> _purchaseCallback, PurchaseConfirmation _purchaseMenu)
    {
        constructionMenu.InitializeMenu(_purchaseCallback, _purchaseMenu);
        detectionMenu.InitializeMenu(_purchaseCallback, _purchaseMenu);
        offersMenu.InitializeMenu(_purchaseCallback, _purchaseMenu);
    }

    public void UpdateButtons(int _totalSouls)
    {
        constructionMenu.UpdateButtons(_totalSouls);
        detectionMenu.UpdateButtons(_totalSouls);
        offersMenu.UpdateButtons(_totalSouls);
    }

    private void Update()
    {
        UpdateButtonInteractivity();
        if (waitingForMenuToClose)
        {
            WaitForMenu();
        }
    }

    private void WaitForMenu()
    {
        if (!CheckForAnimatingMenu())
        {
            OnMenuClosed?.Invoke();
            OnMenuClosed = null;
            waitingForMenuToClose = false;
        }
    }

    private void UpdateButtonInteractivity()
    {
        constructionButton.interactable = !CheckForAnimatingMenu();
        detectionButton.interactable = !CheckForAnimatingMenu();
        offersButton.interactable = !CheckForAnimatingMenu();
    }

    public void OnConstructionMenuPressed()
    {
        if (currentMenuType == MenuType.None)
        {
            constructionMenu.OpenMenu();
            tableAnimator.SetBool("Open", true);
            currentMenuType = MenuType.Construction;
        }
        else if (currentMenuType != MenuType.Construction)
        {
            OnMenuClosed += OnConstructionMenuPressed;
            CloseCurrentMenu();
        }
        else
        {
            constructionMenu.CloseMenu();
            tableAnimator.SetBool("Open", false);
            currentMenuType = MenuType.None;
        }
    }

    public void OnDetectionMenuPressed()
    {
        if (currentMenuType == MenuType.None)
        {
            detectionMenu.OpenMenu();
            tableAnimator.SetBool("Open", true);
            currentMenuType = MenuType.Detection;
        }
        else if (currentMenuType != MenuType.Detection)
        {
            OnMenuClosed += OnDetectionMenuPressed;
            CloseCurrentMenu();
        }
        else
        {
            detectionMenu.CloseMenu();
            tableAnimator.SetBool("Open", false);
            currentMenuType = MenuType.None;
        }
    }

    public void OnOffersMenuPressed()
    {
        if (currentMenuType == MenuType.None)
        {
            offersMenu.OpenMenu();
            tableAnimator.SetBool("Open", true);
            currentMenuType = MenuType.Offer;
        }
        else if (currentMenuType != MenuType.Offer)
        {
            OnMenuClosed += OnOffersMenuPressed;
            CloseCurrentMenu();
        }
        else
        {
            offersMenu.CloseMenu();
            tableAnimator.SetBool("Open", false);
            currentMenuType = MenuType.None;
        }
    }

    private void CloseCurrentMenu()
    {
        switch (currentMenuType)
        {
            case MenuType.Construction:
                constructionMenu.CloseMenu();
                break;

            case MenuType.Detection:
                detectionMenu.CloseMenu();
                break;

            case MenuType.Offer:
                offersMenu.CloseMenu();
                break;

            default:
                Debug.LogError("THIS SHOULDNT HAPPEN");
                break;
        }

        currentMenuType = MenuType.None;

        waitingForMenuToClose = true;
    }

    public void CloseButtonPressed()
    {
        switch (currentMenuType)
        {
            case MenuType.Construction:
                constructionMenu.CloseMenu();
                tableAnimator.SetBool("Open", false);
                currentMenuType = MenuType.None;
                break;

            case MenuType.Detection:
                detectionMenu.CloseMenu();
                tableAnimator.SetBool("Open", false);
                currentMenuType = MenuType.None;
                break;

            case MenuType.Offer:
                offersMenu.CloseMenu();
                tableAnimator.SetBool("Open", false);
                currentMenuType = MenuType.None;
                break;

            default:
                Debug.LogError("THIS SHOULDNT HAPPEN");
                break;
        }
    }

    private bool CheckForAnimatingMenu()
    {
        if (constructionMenu.IsAnimating())
        {
            return true;
        }
        else if (detectionMenu.IsAnimating())
        {
            return true;
        }
        else if (offersMenu.IsAnimating())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
