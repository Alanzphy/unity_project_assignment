using System;
using System.Collections.Generic;

[Serializable]

public class PokeInfo
{
    public int count = 0;
    public string next = "";
    public string previously = "";
    public List<PokemonInfo> results = new List<PokemonInfo>();
}

[Serializable]
public class PokemonInfo
{
    public string name = "";
    public string url = "";
}
