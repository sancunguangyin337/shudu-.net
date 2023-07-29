# shudu-.net
C#实现随机数独游戏
# 1、算法内容：
1、初始化9*9数组，依据数独宫位划分为九宫，0-2列/行为一个宫列/行，3-5列/行为一个宫列/行，6-8列/行为一个宫列/行.
2、运用宫行互换、宫列互换、同宫内的三行互换、同宫内三列互换不影响数独性质，得到4种变换方法；
3、即0-2、3-5、6-8三个工行/列进行互换，宫内0、1、2或3、4、5或6、7、8进行宫内行/列互换；
4、运用随机数对四种变换随机选择以进行设定次数的变换，四种变换算法中又以随机数确定随机交换的宫行列或者宫内行列。
5、最后用随机数按照需要的初始个数显示，为防止随机数重复选中单元格，运用0-80一维数组存储显示位置，随机数范围为0-数组长度，每次随机数选择其中下标对应的数值进行数组单元格显示，并删除该位置的数值，且将数组总长度减一。
# 2、显示优化
1、按照数独玩法，同行列和宫内相同数字只能出现一次，行列内和宫内数字已有的数字不能填入。进行填空提示。通过一个焦点存储器实时存储点击的单元格，进行单元格内容匹配以获取焦点单元格相同数字的位置上绿色意味选择查看的数字，将焦点单元格及相同数字的单元格所在的行列和宫上红色意味着同行列和宫内已有查看的数字。
# 3、填入操作
1、通过一个声明存储焦点对象控件的对象存储上一次点击的空格即选择的空格，进行填时验证填入数字是否对应数组内正确的值（提示超过17个数字的数独有唯一解）。
2、在错误五次直接判为失败。
3、全部单元格填满时判成功。
# 4、难度选择
1、通过设定随机变换次数改变难度（小幅改变难度）初始个数越小难度越高最小十七，十七以下不确定唯一解。
2、通过设定初始显示个数改变难度（大幅影响难度）变换次数越多相比初始数组越混乱，消耗性能和时间越多。
# 5维护联系
1、如果你有更好的想法或算法可以联系邮箱bxca337@outlook.com。
2、如果你对项目算法有疑惑可以联系邮箱bxca337@outlook.com。
3、如果你对项目非常喜欢，捐赠欢迎支付宝15608748670。
