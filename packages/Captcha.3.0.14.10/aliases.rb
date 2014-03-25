require 'fileutils'

wd = File.expand_path(File.dirname(__FILE__))

#puts "#{ %x( #{wd}/nuget.exe update -self ) }"

content = File.read('Captcha.nuspec')
puts "#{ %x( #{wd}/nuget.exe pack #{wd}/Captcha.nuspec ) }"

aliases = %w[BotDetect BotDetectCaptcha]
aliases.each do |al|
  filename = "#{al}.nuspec"
  File.open(filename, 'w+') do |file|
  file.write(content.gsub(/<id>Captcha<\/id>/, "<id>#{al}</id>"))
end
puts "#{ %x( #{wd}/nuget.exe pack #{wd}/#{filename} ) }"
File.delete(filename)
end
