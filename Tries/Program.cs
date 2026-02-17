using Tries;



var trie = new Trie();
trie.Insert("cat");
trie.Insert("canada");

Console.WriteLine(trie.Contains("cat"));     // true
Console.WriteLine(trie.Contains("canada"));  // true

Console.WriteLine(trie.Contains("can"));     // false


trie.Traverse();


trie.Remove("cat");
Console.WriteLine(trie.Contains("cat"));    // false
Console.WriteLine(trie.Contains("canada")); // true



// Auto Completion:
trie = new Trie();              //      ' '
trie.Insert("car");             //   c       e
trie.Insert("card");            //   a       g
trie.Insert("care");            //   r       g
trie.Insert("careful");         // d   e
trie.Insert("egg");             //     f
                                //     u
                                //     l

var words = trie.AutoComplete("car");    // "car", "card", "care", "careful"
var words2 = trie.AutoComplete("care");  // "care", "careful"
Console.WriteLine();

