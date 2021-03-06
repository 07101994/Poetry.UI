﻿


/* LINK BUTTON */

class PortalLinkButton {
    constructor(text, url, target) {
        this.element = document.createElement('a');
        this.element.classList.add('portal-button');
        this.element.href = url;
        this.element.target = target;
        this.element.innerText = text;
    }

    addClass(value, test) {
        if (test) {
            this.element.classList.add(value);
        } else {
            this.element.classList.remove(value);
        }

        return this;
    }

    appendTo(element) {
        element.appendChild(this.element);

        return this;
    }
}