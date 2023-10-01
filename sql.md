


- where过滤行，having过滤分组，所有where字句等能被having取代（分组引入having的概念）
- where在分组前过滤，having在分组后过滤
- GROUP BY子句必须出现在WHERE子句后，ORDER BY子句前

|子句|说明|是否必须使用|
|:-:|:-:|:-:|
|SELECT|要返回的列或表打式|是|
|FROM|从中检索数据的表|仅在从表选择数据时使用|
|WHERE|行级检索|否|
|GROUP BY|分组说明|仅在按组计算聚集时使用|
|HAVING|组级过滤|否|
|ORDER BY|输出排序顺序|否|
|LIMIT|要检索的行数|否|

