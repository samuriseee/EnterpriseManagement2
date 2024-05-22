<template>
  <div class="app-container">
    <el-table
      v-loading="listLoading"
      :data="list"
      element-loading-text="Loading"
      border
      fit
      highlight-current-row
    >
      <el-table-column align="center" label="ID" width="50">
        <template slot-scope="scope">
          {{ scope.$index }}
        </template>
      </el-table-column>
      <el-table-column label="Avatar">
        <template slot-scope="scope">
          <el-avatar :src="scope.row.avatarUrl" />
        </template>
      </el-table-column>
      <el-table-column label="Name">
        <template slot-scope="scope">
          {{ scope.row.name }}
        </template>
      </el-table-column>
      <el-table-column label="Position" align="center">
        <template slot-scope="scope">
          <span>{{ scope.row.position }}</span>
        </template>
      </el-table-column>
      <el-table-column label="Work Email" align="center">
        <template slot-scope="scope">
          <span>{{ scope.row.workEmail }}</span>
        </template>
      </el-table-column>
      <el-table-column align="center" prop="birthday" label="Birthday" width="200">
        <template slot-scope="scope">
          <i class="el-icon-time" />
          <span>{{ scope.row.birthday }}</span>
        </template>
      </el-table-column>
      <el-table-column label="Phone Number" align="center">
        <template slot-scope="scope">
          <span>{{ scope.row.phoneNumber }}</span>
        </template>
      </el-table-column>
      <el-table-column align="center" prop="birthday" label="Join Company Date" width="200">
        <template slot-scope="scope">
          <i class="el-icon-time" />
          <span>{{ scope.row.joinDate }}</span>
        </template>
      </el-table-column>
      <el-table-column class-name="status-col" label="Employee Status" align="center">
        <template slot-scope="scope">
          <el-tag>{{ empStatusEnum[scope.row.status] }}</el-tag>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>

<script>
import { getListEmployee } from '@/api/employee'
import { EmployeeType } from '@/constant/index'

export default {
  data() {
    return {
      list: null,
      listLoading: true,
      empStatusEnum: {
        1: 'Active',
        0: 'Inactive'
      }
    }
  },
  watch: {
    employeeType(employeeType) {
      const employeeTypeMap = {
        [EmployeeType.FULLTIME]: 'Full-time',
        [EmployeeType.PARTTIME]: 'Part-time',
        [EmployeeType.INTERN]: 'Intern'
      }
      return employeeTypeMap[employeeType]
    }
  },
  created() {
    this.fetchData()
  },
  methods: {
    fetchData() {
      this.listLoading = true
      getListEmployee().then(response => {
        this.list = response.data
        console.log(this.list)
        this.listLoading = false
      })
    }
  }
}
</script>
