- 代码获得欧拉角无法产生负数，其值介于(0~360)，因为是通过四元数转换过来的（界面上会有负数，坑！）
- 屏幕坐标转换为世界坐标的时候要设置具体的Z（Z=0时就一个点），`Camera.main.ScreenToWorldPoint(Vector3)`
- 碰撞产生的必要条件：两个物体都有碰撞器，且至少有一个物体有刚体
- 如果是一个异形物体，刚体在父对象上，如果你想通过子对象挂脚本检测碰撞是不行的，必须挂载到这个刚体的父对象才行
- 刚体会休眠，平面上的立方体掉下后静止，此时改变平面角度，立方体还是浮空的，如果改平面高度才会使立方体掉下来
- `this.transform.Find("AAA/BBB.xx")`就可以招子对象的子对象（默认只招一层子对象，所以斜杠可以这样用）

---


- 向量是终点减起点
- `Quaternion.AngleAxis(180, Vector3.up);`这里的角度是相对角度！！！，别用`transform.up`，（猜测四元数没有绝对角度，都是按照自身坐标系旋转的）
- Quaternion建议用球形插值，两者效果差不多，但是极端情况，球形插值更好