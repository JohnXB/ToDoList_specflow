Feature: SignUpAUser
	用户注册

@mytag
Scenario: 用户注册
	Given 我输入昵称和密码"刘东坡""123456"进行注册
	Then 成功注册一个用户
