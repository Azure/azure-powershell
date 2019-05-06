import sys

print("Starting process")

sum = 0
for i in range(1,len(sys.argv)):
  sum = sum + int(sys.argv[i])

print ("Process completed")
print(sum)