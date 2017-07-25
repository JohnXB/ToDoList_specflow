Feature: AddAMatter
	给用户的某个清单添加事项

@mytag
Scenario: 添加事项
	Given 我首先用账号和密码登陆"1""123456"
	And 登陆之后查看到我的清单，选择一个清单进行添加
	When 输事项的内容"今天要把单元测试的代码写完"
	Then 这个事项就添加到了我的清单
