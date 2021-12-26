#include <stdio.h>
#include <vector>
#include <algorithm>
#include <cassert>

struct  Info
{

	bool possible;

	int nOnes;

	int lastDigit;

	int prevResult;

};

int main()
{
	int n;
	scanf("Xd", &n);
	int f[2][2];
	scanf("%1d%1d%1d%1d", &f[0][0], &f[0][1], &f[1][0], &f[1][1]);
	std::vector<std::vector<Info>> info(2, std::vector<Info>(1 + n, Info{ false, 0, -1, -1 })); // [result][len] -> info
	info[0][1].possible = true;
	info[0][1].nOnes = 0;
	info[0][1].lastDigit =  0;
	info[0][1].prevResult = -1;
	info[1][1].possible = true;
	info[1][1].nOnes = 1;
	info[1][1].lastDigit = 1;
	info[1][1].prevResult = -1;
	for (int len = 2; len <= n; len++)
	{
		for (int prevResult = 0; prevResult <= 1; prevResult++)
		{
			if (!info[prevResult][len - 1].possible)
			{
				continue;
			}
			for (int lastDigit = 0; lastDigit <= 1; lastDigit++)
			{
				int result = f[prevResult][lastDigit];
				int nOnes = info[prevResult][len - 1].nOnes + lastDigit;
				if (!info[result][len].possible || nOnes > info[result][len].nOnes)
				{
					info[result][len].possible = true;
					info[result][len].nOnes = nOnes;
					info[result][len].lastDigit = lastDigit;
					info[result][len].prevResult = prevResult;
				}
			}
		}
	}
	if (!info[1][n].possible)
	{
		printf("No solution");
		return 0;
	}
	std::vector<int> ans;
	int result = 1;
	int len = n;
	while (len > 0)
	{
		assert(info[result][len].possible);
		ans.push_back(info[result][len].lastDigit);
		result = info[result][len].prevResult;
		len--;
	}
	std::reverse(ans.begin(), ans.end());
	for (int value : ans)
	{
		printf("%d", value);
	}
	return 0;
}