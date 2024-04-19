export function get(key)
{
    return window.localStorage.getItem(key);
}

export function set(key, value, element)
{
    window.localStorage.setItem(key, value);
    element.disabled = true;
}

export function clear()
{
    window.localStorage.clear();
}

export function remove(key)
{
    window.localStorage.removeItem(key);
}