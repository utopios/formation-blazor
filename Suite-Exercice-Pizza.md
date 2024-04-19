### Suite TP Pizza

- En utilisant le fichier JS suivant qui permet de stocker dans le LocalStorage, Ajoutez un bouton favoris pour stocker les pizzas favorites dans le localStorage du navigateur.

```JS
export function get(key)
{
    return window.localStorage.getItem(key);
}

export function set(key, value)
{
    window.localStorage.setItem(key, value);
}

export function clear()
{
    window.localStorage.clear();
}

export function remove(key)
{
    window.localStorage.removeItem(key);
}

```