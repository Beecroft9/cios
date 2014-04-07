﻿(function ($) {
    $.fn.dmDropDownMenu = function () {
        return this.each(function () {
            var _dmMenu = { aryVisibleContainers: [], timeout: null, containerHide: function (container) { $(container).css("visibility", "hidden"); var p = container.parent_A; do { $(p).removeClass("mouseover"); } while (p = p.parent_DIV.parent_A && p.parent_DIV.level >= container.level) }, containerShow: function (container) { $(container).css("visibility", "visible"); var p = container.parent_A; do { $(p).addClass("mouseover"); } while (p = p.parent_DIV.parent_A) } }; var topLevelContainerEl = this; topLevelContainerEl.level = 0; var elements = $("*", this); var level = 0; var firstLevel; $("div", this).each(function () { this.parent_A = $(this).prev("a").get(0); if (firstLevel === undefined) firstLevel = $(this).parents().size() - 1; this.level = $(this).parents().size() - firstLevel; this.dmMenu = _dmMenu; }); $("a", this).each(function () { this.parent_DIV = $(this).parent().get(0); this.child_DIV = $(this).next("div").get(0); this.level = $(this).parents().size() - firstLevel; this.dmMenu = _dmMenu; }); $("div", this).each(function () { var container = this.parentNode.removeChild(this); topLevelContainerEl.appendChild(container); zIndexController.setToHighest(container); }); $("a", this).mouseover(function () {
                $(this).addClass("mouseover"); for (var k = this.dmMenu.aryVisibleContainers.length; k > this.parent_DIV.level; k--) { this.dmMenu.containerHide(this.dmMenu.aryVisibleContainers.pop()); }
                if (this.child_DIV) {
                    var l1OffsetX = 0; var l1OffsetY = 0; var l2OffsetX = 0; var l2OffsetY = 0; if (this.child_DIV.level == 1) {
                        this.child_DIV.style.left = $(this).offset().left + l1OffsetX + "px"; this.child_DIV.style.top = $(this).offset().top +
                        $(this).outerHeight(false) + l1OffsetY + "px";
                    } else {
                        this.child_DIV.style.left = $(this).offset().left +
                        $(this).outerWidth(false) + l2OffsetX + "px"; this.child_DIV.style.top = $(this).offset().top + l2OffsetY + "px";
                    }
                    this.dmMenu.containerShow(this.child_DIV); this.dmMenu.aryVisibleContainers.push(this.child_DIV);
                }
            }); $("a", this).mouseout(function () { if (!this.child_DIV) $(this).removeClass("mouseover"); }); $("div", this).mouseover(function () { window.clearTimeout(this.dmMenu.timeout); }); $("div", this).mouseout(function () {
                var el = this; window.clearTimeout(this.dmMenu.timeout); this.dmMenu.timeout = window.setTimeout(function () {
                    for (var k = 0; el.dmMenu.aryVisibleContainers && k < el.dmMenu.aryVisibleContainers.length; k++)
                    { el.dmMenu.containerHide(el.dmMenu.aryVisibleContainers[k]); }
                    el.dmMenu.aryVisibleContainers = [];
                }, 500);
            });
        });
    }
    var zIndexController = function () {
        var highestZIndex = function () {
            var highestZIndex = 1; var allElements = document.getElementsByTagName('*'); for (var k = 0; k < allElements.length; k++) {
                if (allElements[k].style.zIndex > highestZIndex)
                    highestZIndex = allElements[k].style.zIndex;
            }
            return highestZIndex;
        }(); return { setToHighest: function (element) { highestZIndex++; element.style.zIndex = highestZIndex; } };
    }();
})(jQuery);