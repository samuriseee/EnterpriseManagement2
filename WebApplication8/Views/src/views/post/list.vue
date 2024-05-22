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
      <el-table-column align="center" width="50" label="ID">
        <template slot-scope="scope">
          {{ scope.$index }}
        </template>
      </el-table-column>
      <el-table-column label="Title">
        <template slot-scope="scope">
          {{ scope.row.title }}
        </template>
      </el-table-column>
      <el-table-column label="Post Type" align="center">
        <template slot-scope="scope">
          <span>{{ BlogPostType[scope.row.type] }}</span>
        </template>
      </el-table-column>
      <el-table-column
        fixed="right"
        label="Operations"
        width="120"
      >
        <template slot-scope="scope">
          <el-button type="text" size="small" @click="handleGoToDetail(scope.row.id)">Detail</el-button>
          <el-button type="text" size="small">Edit</el-button>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>

<script>
import { getListPost } from '@/api/post'
export default {
  filters: {
    statusFilter(status) {
      const statusMap = {
        published: 'success',
        draft: 'gray',
        deleted: 'danger'
      }
      return statusMap[status]
    }
  },
  data() {
    return {
      list: null,
      listLoading: true,
      BlogPostType: {
        1: 'Company information',
        2: 'Company Work Shcedule'
      }
    }
  },
  created() {
    this.fetchData()
  },
  methods: {
    fetchData() {
      this.listLoading = true
      getListPost().then(response => {
        this.list = response.data
        console.log(this.list)
        this.listLoading = false
      })
    },
    handleGoToDetail(id) {
      this.$router.push({ path: `/post/detail/${id}` })
    }
  }
}
</script>
