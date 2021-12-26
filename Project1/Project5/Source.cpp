#include <iostream>
#include <string>
#include <fstream>
#include <algorithm>
using namespace std;

int main()
{
    string t, rebus, words;
    int n, m, pos;
    ifstream fin("input.txt");
    fin >> n >> m;
    for (int i = 0; i < n; ++i)
    {
        fin >> t;
        rebus += t;
    }
    for (int i = 0; i < m; ++i)
    {
        fin >> t;
        words += t;
    }
    for (int i = 0; i < words.size(); ++i)
    {
        pos = rebus.find(words[i]);
        rebus.erase(pos, 1);
    }
    sort(rebus.begin(), rebus.end());
    cout << rebus;
    return 0;
}